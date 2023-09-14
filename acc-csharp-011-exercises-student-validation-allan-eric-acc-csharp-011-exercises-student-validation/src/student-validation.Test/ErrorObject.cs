using System.Collections.Generic;

namespace student_validation.ResponseModels;
 
public class ErrorObject
{
    public int Status { get; set; }
    public Dictionary<string, List<string>> Errors { get; set; } = null!;
}
 