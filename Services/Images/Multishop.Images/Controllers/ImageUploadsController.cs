using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multishop.Images.Context;
using Multishop.Images.Entities;
using Multishop.Images.Services;
using System.Security.Cryptography.Xml;

namespace Multishop.Images.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadsController(ICloudStorageService _cloudStorageService,ImagesContext _context) : ControllerBase
    {
        private async Task GenerateSignedUrl(ImageDrive image)
        {
            // Get Signed URL only when Saved File Name is available.
            if (!string.IsNullOrWhiteSpace(image.SavedFileName))
            {
                image.SignedUrl = await _cloudStorageService.GetSignedUrlAsync(image.SavedFileName);
            }
        }

        private string? GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);
            return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
        }

        [HttpPost]
        public async Task<IActionResult> Create(ImageDrive image)
        {
            if (image.Photo != null)
            {
                image.SavedFileName = GenerateFileNameToSave(image.Photo.FileName);
                image.SavedUrl = await _cloudStorageService.UploadFileAsync(image.Photo, image.SavedFileName);
            }

            _context.ImageDrives.Add(image);
            _context.SaveChanges();
            return Ok("Resim Oluşturuldu");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var referees = await _context.ImageDrives.ToListAsync();
            foreach (var referee in referees)
            {
                await GenerateSignedUrl(referee);

            }
            return Ok(referees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ImageDrives == null)
            {
                return NotFound();
            }

            var referee = await _context.ImageDrives.FindAsync(id);
            if (referee == null)
            {
                return NotFound();
            }
            await GenerateSignedUrl(referee);
            return Ok(referee);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(ImageDrive image)
        {
            if (image.Id ==null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await ReplacePhoto(image);
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.Id))
                    {
                        return BadRequest();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(image);
            }
            return BadRequest();
        }

        private async Task ReplacePhoto(ImageDrive image)
        {
            if (image.Photo != null)
            {
                //replace the file by deleting referee.SavedFileName file and then uploading new referee.Photo
                if (!string.IsNullOrEmpty(image.SavedFileName))
                {
                    await _cloudStorageService.DeleteFileAsync(image.SavedFileName);
                }
                image.SavedFileName = GenerateFileNameToSave(image.Photo.FileName);
                image.SavedUrl = await _cloudStorageService.UploadFileAsync(image.Photo, image.SavedFileName);
            }
        }

        private bool ImageExists(int id)
        {
            return _context.ImageDrives.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.ImageDrives == null)
            {
                return NotFound("Entity set is null.");
            }
            var referee = await _context.ImageDrives.FindAsync(id);
            if (referee != null)
            {
                if (!string.IsNullOrWhiteSpace(referee.SavedFileName))
                {
                    await _cloudStorageService.DeleteFileAsync(referee.SavedFileName);
                    referee.SavedFileName = String.Empty;
                    referee.SavedUrl = String.Empty;
                }
                _context.ImageDrives.Remove(referee);
            }

            await _context.SaveChangesAsync();
            return Ok("Resim Silindi");
        }


    }
}
