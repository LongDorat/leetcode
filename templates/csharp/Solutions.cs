namespace TemplateProject;

public interface ISolutions
{
    /// <summary>
    /// Add a short summarization for this solution
    /// </summary>
    /// <param name="parameter"> Add a description for the parameter</param>
    /// <returns> Add a description for the return value</returns>
    /// <remarks> Time Complexity: O(?) | Space Complexity: O(?) </remarks>
    ReturnType SolutionName(ParameterType parameter);
}

public class Solutions : ISolutions
{
    public ReturnType SolutionName(ParameterType parameter)
    {
        // Implementation here
        return result;
    }
}
