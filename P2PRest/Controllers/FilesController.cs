using Microsoft.AspNetCore.Mvc;
using P2PRest.Models;
using P2PRest.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2PRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private FilesRepository _repository;

        public FilesController(FilesRepository repository)
        {
            _repository = repository;
        }


        // GET: api/<FileEndPointsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult <List<string>> Get()
        {
            List<string> filenames = _repository.GetAllFileNames().ToList();
            if(filenames.Count < 1 )
            {
                return NoContent();
            }
            return Ok(filenames);
        }

        // GET api/<FileEndPointsController>/5
        [HttpGet("{filename}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<FileEndPoint>> Get(string filename)
        {
            List<FileEndPoint> foundEndPoints = _repository.GetFileEndPoints(filename).ToList();
            if (foundEndPoints.Count < 1)
            {
                return NoContent();
            }
            return Ok(foundEndPoints);
        }

        // POST api/<FileEndPointsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FileEndPoint> Post([FromBody] FileEndPoint endpoint, string filename)
        {
            try
            {
                _repository.AddEndpoint(filename, endpoint);
                return Created($"api/files/{filename}", endpoint);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<FileEndPointsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FileEndPointsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
