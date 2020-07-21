using System;
using System.Collections.Generic;
using System.Text;

namespace auth_test.demo.Domain.Services
{
    public interface IPasswordService
    {
        string ComputePasswordHash(string password);
    }
}
