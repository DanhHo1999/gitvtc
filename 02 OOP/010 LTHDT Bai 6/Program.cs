namespace _25_05_010_LTHDT_Bai_6 {
    internal class Program {
        
        static void Main(string[] args) {
            Account acc1=new Account("Ted Murphy",73254,102.56);
            Account acc2=new Account("Jane Smith", 69713, 40.00);
            Account acc3=new Account("Edward Demsey", 93757, 759.32);

            acc1.Deposit(25.85);
            acc2.Deposit(500);
            acc2.Withdraw(430.75, 1.5);
            acc3.AddInterest();
            acc1.ToString();
            acc2.ToString();
            acc3.ToString();


            acc2.Transfer(ref acc1, 100);
            acc2.Transfer(ref acc1, 100);
            acc2.Transfer(ref acc1, 100);
            acc2.Transfer(ref acc1, 100);
            acc2.Transfer(ref acc1, 100);
            acc2.Transfer(ref acc1, 100);
            acc1.ToString();
            acc2.ToString();

        }
    }
}