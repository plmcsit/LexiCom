using System.Collections.Generic;

namespace Core.Library
{
    public class SyntaxProductions
    {
        private string Productions = "";
        private string RecursiveProductions = "";
        private List<int> ProductionCode = new List<int>();
        private List<string> ProductionState = new List<string>();

        public void AddProductionCode(int code)
        {
            this.ProductionCode.Add(code);
        }

        public int GetLastProductionCode()
        {
            int last = ProductionCode.Count - 1;
            return this.ProductionCode[last];
        }

        public void AddProductionState(string state)
        {
            this.ProductionState.Add(state);
        }

        public string GetLastProductionState()
        {
            int last = ProductionState.Count - 1;
            return this.ProductionState[last];
        }

        public List<string> GetAllProductionState()
        {
            return this.ProductionState;
        }

        public List<int> GetAllProductionCode()
        {
            return this.ProductionCode;
        }

        public void AddProduction(string Productions)
        {
            this.Productions += Productions;
        }
        public string GetProductions()
        {
            return this.Productions;
        }
        public void AddRecursiveProduction(string RecursiveProductions)
        {
            this.RecursiveProductions += RecursiveProductions;
        }
        public string GetRecursiveProductions()
        {
            return this.RecursiveProductions;
        }
    }
}
