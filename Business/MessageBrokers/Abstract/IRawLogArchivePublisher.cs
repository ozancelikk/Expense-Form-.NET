using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.MessageBrokers.Abstract
{
    public interface IRawLogArchivePublisher
    {
        IResult Add(string log, string collectionName);
    }
}
