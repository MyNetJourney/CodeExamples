﻿using System.Collections.Generic;
using ReadDateTakenInfoFromPhoto._01._BaseModel;

namespace ReadDateTakenInfoFromPhoto._03._Processor
{
    internal interface ISortingAlgorithm
    {
        List<PhotoFolder> SortStructure(List<PhotoFolder> inputStructure);
    }
}