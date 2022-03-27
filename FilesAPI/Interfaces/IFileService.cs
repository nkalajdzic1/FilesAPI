using FilesAPI.Dtos;
using FilesAPI.Responses;

namespace FilesAPI.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        ///  get files from the mongo database
        /// </summary>
        /// <returns>list of files from the database</returns>
        public Task<List<FileModelDto>> Get();

        /// <summary>
        /// upload file to the mongo database
        /// </summary>
        /// <param name="file">file from the form</param>
        /// <returns>uploaded file</returns>
        public Task<Response<UploadedFileDto>> Upload(IFormFile file);
    }
}
