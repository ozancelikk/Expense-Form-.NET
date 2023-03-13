using Core.Entities.Concrete;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Core.Utilities.DeDuplications
{
    public interface IDeDuplicationServices
    {
        List<PipelineDefinition<GroupCountAggregation, GroupCountAggregation>> CreateAggregationBetweenTwoDates(string startDate,string endDate);
    }
}
