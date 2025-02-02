using NUnit.Framework.Constraints;

namespace Domain.Test.DSL {
    internal class WorkItemConstraint : Constraint {
        private readonly string expected;

        public WorkItemConstraint(string expected) : base(expected) {
            this.expected = expected;
        }

        public override string Description => $"\"{expected}\"";

        public override ConstraintResult ApplyTo<TActual>(TActual actual) {
            return new ConstraintResult(this, actual, AreEquivalent(actual));
        }

        private bool AreEquivalent<TActual>(TActual actual) {
            if (actual is not WorkItem workItem) return false;

            return $"{workItem.BacklogItem.Name}.{workItem.Component.Name}" == expected;
        }
    }
}