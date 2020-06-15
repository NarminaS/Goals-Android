using Goals.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goals.Services.Repositories.Abstract
{
    public interface IAuthRepository
    {
        ApplicationUser GetUser();
    }
}
