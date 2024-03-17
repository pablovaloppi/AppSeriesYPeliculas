using Contracts;
using System.Text.RegularExpressions;

namespace ApiSeriePeliculas.Core.Services
{
    public class UploadService
    {
        private ILoggerManager _logger;
        public UploadService(ILoggerManager logger)
        {
            _logger = logger;
        }

        public bool IsImage(string fileName) {
            Regex regex = new Regex( @"([/|.|_|\\w|\\s|-])*\.(?:jpg|jpeg|pjpeg|jfif|pjp|png)" );
            if(!regex.IsMatch(fileName)) {
                return false;
            }
            return true;
        }
    }
}
