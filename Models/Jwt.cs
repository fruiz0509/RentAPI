using RentAPI.Repository;
using System.Security.Claims;

namespace RentAPI.Models
{
    public class Jwt
    {
        private static  IRepository<User>? _userRepository;
        public Jwt(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public Jwt()
        {

        }

        public string? Key { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? Subject { get; set; }

        //Validar que se recibe un token valido
        public static dynamic ValidarToken(ClaimsIdentity identity) 
        {
            try
            {
                if (identity.Claims.Count() == 0)
                {
                    return new
                    {
                        success = false,
                        message = "Verificar si estas enviando un token valido",
                        result = "",
                    };
                }

                var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;

                User? user = _userRepository.Get(Int16.Parse(id));

                return new
                {
                    success = true,
                    message = "exito",
                    result = user
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = "Error: " + ex.Message,
                    result = ""
                };
            }
        }

    }
}
