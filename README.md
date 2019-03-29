
# Decscription
Created a Cities webAPI where it has the ID(pk) and points of interestes in that city. I used HttpPut, HttpGet, HttpPost, HttpPatch, HttpDelete etc to perform CRUD operations in it. 

## Creation.
```
 [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult createPointOfInterest(int cityId,
            [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//We return the error message if field is empty
            }
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var maxPointOfInterestId = CitiesDataStore.Current.Cities
                .SelectMany(c => c.PointsOfInterest).Max(p => p.Id);
            var finalPointOfInterest = new PointOfInterest()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };
            city.PointsOfInterest.Add(finalPointOfInterest);
            return CreatedAtRoute("GetPointOfInterest", new
            { cityId = cityId, id = finalPointOfInterest.Id, finalPointOfInterest });
        }
```



```
[HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterests(int cityId) {
            try
            {
                //throw new Exception("Exception Sample");
                var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
                if (city == null)
                {
                    _logger.LogInformation($"City with id {cityId} was't found when accessing the points of interest");
                    return NotFound();
                }
                return Ok(city.PointsOfInterest);
            }
            catch (Exception)
            { 
               //
               
               _logger.LogCritical($"Exception while getting points of interest with id {cityId}",ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }`

       [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int id) {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }
```
## Update

```      
 [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult createPointOfInterest(int cityId,
            [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//We return the error message if field is empty
            }
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var maxPointOfInterestId = CitiesDataStore.Current.Cities
                .SelectMany(c => c.PointsOfInterest).Max(p => p.Id);
            var finalPointOfInterest = new PointOfInterest()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };
            city.PointsOfInterest.Add(finalPointOfInterest);
            return CreatedAtRoute("GetPointOfInterest", new
            { cityId = cityId, id = finalPointOfInterest.Id, finalPointOfInterest });
        }
  ```
  
  ## Retrieve
  ```
  [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterests(int cityId) {
            try
            {
                //throw new Exception("Exception Sample");
                var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
                if (city == null)
                {
                    _logger.LogInformation($"City with id {cityId} was't found when accessing the points of interest");
                    return NotFound();
                }
                return Ok(city.PointsOfInterest);
            }
            catch (Exception)
            { 
               //
               
               _logger.LogCritical($"Exception while getting points of interest with id {cityId}",ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }`

       [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int id) {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }
   ```
   ## Delete
   
   ```
   [HttpDelete("{cityId}/pointsofinterest/{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            city.PointsOfInterest.Remove(pointOfInterestFromStore);

            _mailService.Send("Point of Internet deleted.",
                 $"Point of interest {pointOfInterestFromStore.Name} with id {pointOfInterestFromStore.Id} was deleted");

            return NoContent();
        }
```
## Patch

```
[HttpPatch("{cityId}/pointsofinterest/{id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int id,
            [FromBody] JsonPatchDocument<PointOfInterestForUpdate> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch =
                new PointOfInterestForUpdate()
                {
                    Name = pointOfInterestFromStore.Name,
                    Description = pointOfInterestFromStore.Description
                };

            patchDoc.ApplyTo(pointOfInterestToPatch, ModelState);
            //Checking for the existence of Patch
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Just in case if the user gives the same name as the description.
            if (pointOfInterestToPatch.Description == pointOfInterestToPatch.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name");
            }

            TryValidateModel(pointOfInterestToPatch);

            //Updating it.
            pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
            pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

            return NoContent();
        }
 ```
 # Services
 Admin will be updated when the data is deleted from the json file. The email address is stored in the app.json file to protect the email address and safely store the data. 
 ```


namespace CityDetails.Services
{
    public class CloudMailService:IMailService
    {

        private string _mailTo = "mailsettings: mailToAddress";
        private string _mailFrom = "mailsettings: mailFromAddress";

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMailService");//Just added it to Debug line.
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}
```
## Code First Migration.
1) Created the data base using the EFCore. 
2) Generated the migrations to keep track of the database changes.
