﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DomainUtility.Base
{
    public interface ICommandHandler<in TCommand, out TResult> where TCommand : ICommand<TResult>
    {
        TResult Execute();

    }
}
