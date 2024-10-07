using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDempeño.Repositories;

namespace PruebaDempeño.Controllers.V1.Users;

    [ApiController]
    [Route("api/v1/users")]
    public partial class UsersController(IUserRepository userRepository) : ControllerBase
    {
        protected readonly IUserRepository _userRepository = userRepository;
    }
    


