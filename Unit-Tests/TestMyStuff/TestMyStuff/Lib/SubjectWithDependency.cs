namespace TestMyStuff.Lib
{
    public class SubjectWithDependency
    {
        private readonly IDependency dependency;

        public SubjectWithDependency(IDependency dependency) => 
            this.dependency = dependency;

        public void Operation()
        {
            dependency.Operation();
        }
    }
}