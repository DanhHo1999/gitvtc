using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_05_010_LTHDT_Bai_6
{
    internal class Account
    {
        long accountNumber;
        string name;
        double balance;
        const double RATE = 0.035;
        public void SetAccountNumber(long _accountNumber) {
            if (_accountNumber > 0) accountNumber = _accountNumber;
            else accountNumber = 999999;
        }
        public void SetName(string _name) {
            if (_name != null && _name != "")
            {
                name = _name;
            }
            else name = "Chua Xac Dinh";
        }
        public void SetBalance(double _balance) {
            if (_balance >= 500) balance = _balance;
            else balance = 500;
        }
        public Account() {
            SetAccountNumber(0);
            SetName(null);
            SetBalance(0);
            
        }
        public Account(long _accountNumber, string _name) {
            SetAccountNumber(_accountNumber);
            SetName(_name);
            SetBalance(0);
            ToString();
        }
        public Account(string _name,long _accountNumber,double _balance)
        {
            SetAccountNumber(_accountNumber);
            SetName(_name);
            SetBalance(_balance);
            ToString();
        }
        public bool Deposit(double _amount)
        {
            if (_amount <= 0) return false;
            balance += _amount;
            Console.WriteLine("\nDeposited : "+_amount+" to "+ name);
            
            return true;
        }
        public bool Withdraw(double _amount,double _fee) {
            if (_amount + _fee > balance) return false;
            balance -= _amount + _fee;
            Console.WriteLine("\nWithdrawed : " + _amount + " from " + name);
            
            return true;
        }
        public void AddInterest() {
            Console.WriteLine("\n"+ name + " : Interest : "+Math.Round((balance * RATE),2)+"\n");
            balance += balance * RATE;
            

        }
        public bool Transfer(ref Account account2,double _amount) {
            if (balance >= _amount) {
                balance -= _amount;
                account2.balance += _amount;
                Console.WriteLine(String.Format("{0} transfered {1} to {2}\n", name, _amount,account2.name));
                return true;
            }
            Console.WriteLine("Can't transfer");
            return false;
        }
        public void ToString() {
            Console.WriteLine(String.Format("{0,10} | {1,20} | {2,15:#,##0.00}", accountNumber, name, balance)); 
        }
    }
}
