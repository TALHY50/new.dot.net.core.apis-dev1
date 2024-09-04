using Microsoft.Extensions.Logging;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.Business.Application.Features.UserSettings;

public class UserSettingBase : ApiControllerBase
{
    public UserSettingBase()
    {

    }
    protected UserSettingBase(ILogger<UserSettingBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }
}
