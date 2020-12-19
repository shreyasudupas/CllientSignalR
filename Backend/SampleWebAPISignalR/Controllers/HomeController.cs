using SampleWebAPISignalR.Models;
using SampleWebAPISignalR.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleWebAPISignalR.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllMessages()
        {
            DatabaseRepository _repo = new DatabaseRepository();
            List<Messages> messages = new List<Messages>();
            messages = _repo.GetAllMessage();
            return Ok(messages);

            //return Ok();
        }

        //send the updated message from db server to API
        [HttpPost]
        public IHttpActionResult UpdateResult(List<Messages> messages)
        {
            MessagesHub.MessageHub hub = new MessagesHub.MessageHub();
            try
            {
                //MessagesHub.MessageHub.SendMessage(messages);
                hub.SendMessage(messages);

                return Ok();
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            finally
            {
                hub.Dispose();
            }
        }

        [HttpPost]
        public IHttpActionResult InsertMessage(Messages msg)
        {
            try
            {
                var returnvalue = "";
                DatabaseRepository databaseRepository = new DatabaseRepository();
                var res = databaseRepository.insertMessage(msg);
                if (res == 1)
                    returnvalue = "success";
                else
                    returnvalue = "not success";
                return Ok(returnvalue);
            }catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
