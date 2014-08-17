using System.Collections.Generic;
using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface ISearchProvider {
        List<GuitarTransportType> Search(string brand, string model, string color);
    }
}