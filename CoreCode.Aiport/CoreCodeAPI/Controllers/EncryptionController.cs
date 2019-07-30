using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CoreCode.API.Core.Helpers;


namespace CoreCodeAPI.Controllers
{
    public class EncryptionController : ApiController
    {
        // GET: Encryption
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/encryption/encrypt/{text}")]
        public IHttpActionResult encrypt(string text)
        {
            String EncryptedText = EncryptionHelper.Encrypt(text);
            return Ok(EncryptedText);
                       
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/encryption/decrypt/{text}")]
        public IHttpActionResult decrypt(string text)
        {

            return Ok(EncryptionHelper.GetEncryptedMd5Value(text));

        }
    }
}