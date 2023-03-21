using Microsoft.AspNetCore.Mvc;
using P2PRest.Models;

namespace P2PRest.Repositories
{
    public class FilesRepository
    {

        private Dictionary<string, List<FileEndPoint>> _fileDictionary;

        public FilesRepository()
        {
            _fileDictionary = new Dictionary<string, List<FileEndPoint>>();
            List<FileEndPoint> endPoints = new List<FileEndPoint>() 
            { 
                new FileEndPoint() {IPaddress = "10.10.10.10",PortNumber = 80 },
                new FileEndPoint() {IPaddress = "185.10.100.10",PortNumber = 100 },
                new FileEndPoint() {IPaddress = "100.110.104.100",PortNumber = 44 }
            };

            _fileDictionary.Add("file1", endPoints);
            _fileDictionary.Add("file2", endPoints);
            _fileDictionary.Add("file3", endPoints);

        }

        public IEnumerable<string> GetAllFileNames()
        {
            return _fileDictionary.Keys; 
        }

        public IEnumerable<FileEndPoint> GetFileEndPoints(string filename)
        {
            if (_fileDictionary.ContainsKey(filename))
            {
                return _fileDictionary[filename];
            }
            else
            {
                return null;
            }
        }

        public void AddEndpoint(string filename, FileEndPoint endpoint)
        {
            if(!_fileDictionary.ContainsKey(filename))
            {
                _fileDictionary.Add(filename, new List<FileEndPoint>());
                _fileDictionary[filename].Add(endpoint);
            }
            else
            {
                _fileDictionary[filename].Add(endpoint);
            }
        }

        public void RemoveEndpoint(string filename, FileEndPoint endpoint)
        {
            _fileDictionary[filename].Remove(endpoint);
        }

    }
}
