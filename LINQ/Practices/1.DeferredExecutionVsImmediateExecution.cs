namespace LINQ.Practices
{
    public class DeferredExecutionVsImmediateExecution
    {
        public DeferredExecutionVsImmediateExecution()
        {
            DeferredExecution();
            ImmediateExecution();
        }
        public void DeferredExecution()
        {
            IEnumerable<int> numbers = Enumerable.Range(1, 10).Where(n => n % 2 == 0); // Query is not executed yet
            numbers = numbers.Where(n => n % 4 == 0); // Query is not executed yet

            foreach (var num in numbers) // Execution happens here
            {
                Console.WriteLine(num);
            }
        }
        public void ImmediateExecution()
        {
            List<int> numbers = Enumerable.Range(1, 10).Where(n => n % 2 == 0).ToList(); // Query executes immediately
            numbers = numbers.Where(n => n % 4 == 0).ToList();// Query executes immediately

            foreach (var num in numbers) // Already materialized, no further execution
            {
                Console.WriteLine(num);
            }
        }
    }
}

// In Deffered execution recomputations(-)  low memory usage(+)
//In Immediate execution memory usage(-) no recomputations(+)
//note: A new list will be created Whenever you give ToList(). Aware of it. 