using System.Collections.Generic;

namespace RestWithASPNETCore.Data.Converter
{
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> ParseList(List<O> origins);
    }
}
