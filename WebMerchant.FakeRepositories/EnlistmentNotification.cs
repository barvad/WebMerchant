using System;
using System.Diagnostics;
using System.Transactions;

namespace WebMerchant.FakeRepositories
{
    public class EnlistmentNotification : IEnlistmentNotification
    {
        private readonly Action _prepare;
        private readonly Action _commit;
        private readonly Action _rollBack;
        private readonly string _transactionId;

        public EnlistmentNotification(Transaction transaction,Action prepare, Action commit, Action rollBack)
        {
            _prepare = prepare;
            _commit = commit;
            _rollBack = rollBack;
            transaction.EnlistVolatile(this, EnlistmentOptions.None);
            _transactionId = transaction.TransactionInformation.LocalIdentifier;
        }

        public void Commit(Enlistment enlistment)
        {
            _commit?.Invoke();
            enlistment.Done();
        }

        public void InDoubt(Enlistment enlistment)
        {
            enlistment.Done();
        }

        public void Prepare(PreparingEnlistment preparingEnlistment)
        {
            try
            {
                _prepare?.Invoke();
                preparingEnlistment.Prepared();
            }
            catch (Exception ex)
            {
                preparingEnlistment.ForceRollback(ex);
                
            }
        }


        public void Rollback(Enlistment enlistment)
        {
            _rollBack?.Invoke();
            enlistment.Done();
        }
    }
}