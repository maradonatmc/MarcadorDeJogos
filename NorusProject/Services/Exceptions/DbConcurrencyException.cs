using System;

namespace NorusProject.Services.Exceptions {
    public class DbConcurrencyException : ApplicationException {
        public DbConcurrencyException(string message) : base(message) {
        }
    }
}
