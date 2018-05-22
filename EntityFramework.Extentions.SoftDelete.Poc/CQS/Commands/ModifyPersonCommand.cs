namespace EntityFramework.Extentions.SoftDelete.Poc.CQS.Commands
{
    public class ModifyPersonCommand
    {
        public string Name { get; }
        public bool IsDelete { get; }

        public ModifyPersonCommand(string name, bool isDelete)
        {
            Name = name;
            IsDelete = isDelete;
        }
    }
}
