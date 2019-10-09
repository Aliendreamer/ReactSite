using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyDomain.Interfaces
{
    public   interface ITokenFactory
    {
        string GenerateToken(int size = 32);
    }
}
