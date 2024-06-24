using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotographyPortfolio.Contracts.Request;
using PhotographyPortfolio.Helpers;
using PhotographyPortfolio.Services.Interfaces;

namespace PhotographyPortfolio.Controllers;

public class PhotoController : Controller
{
    private readonly IPhotoService? _photoService;

    public PhotoController(IPhotoService photoService)
    {
        _photoService = photoService ?? throw new ArgumentNullException();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Gallery()
    {
        var result = _photoService!.GetGallery();

        if (result == null)
        {
            return NotFound();
        }

        return View(result);
    }

    public IActionResult Upload()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(UploadRequest request)    
    {
        // Check if the request is null
        if (request == null)
        {
            ModelState.AddModelError(string.Empty, "Request cannot be null.");
        }
        else if (request.File == null || !PhotoHelper.IsImageFile(request.File))  // Check if file is null or not an image
        {
            ModelState.AddModelError("File", "Please upload a valid image file.");
        }

        if (ModelState.IsValid)
        {
            await _photoService!.UploadAsync(request.File!, request.Title!, request.Description!);
            ViewData["UploadSuccess"] = true;
            return View();
        }

        ViewData["UploadSuccess"] = false;
        return View(request);
    }

    [HttpPost]
    public IActionResult Gallery(int id)
    {
        _photoService!.DeletePhoto(id);

        return RedirectToAction(nameof(Gallery)); // Redirect to the gallery page
    }
}
