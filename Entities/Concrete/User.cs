
using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public User(string fullName,string email):base(email)
		{
			FullName = fullName;
			Email = email;
		}
        public User()
        {
            
        }
    }
}