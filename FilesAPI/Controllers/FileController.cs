using FilesAPI.Data;
using FilesAPI.Dtos;
using FilesAPI.Interfaces;
using FilesAPI.Models;
using FilesAPI.Requests;
using FilesAPI.Responses;
using FilesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilesAPI.Controllers
{
    [ApiController]
    [Route("api/v1/files")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<List<FileModelDto>> Get() => await _fileService.Get();

        [HttpPost]
        public async Task<Response<UploadedFileDto>> Upload([FromForm] FileUploadRequest fileReq)
        {
            return await _fileService.Upload(fileReq.File);
        }
    }
}