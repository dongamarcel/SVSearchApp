using System;

namespace SimonsVoss.Infra.Interfaces
{
    public interface ISearchWeightConfiguration
    {
        Type Type { get; }
        string FieldName { get; }
        int Weight { get; }
        Type CrossReferencedType { get; }
        int CrossReferencedWeight { get; }
    }
}
