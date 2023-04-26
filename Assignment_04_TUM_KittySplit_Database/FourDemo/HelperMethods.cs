
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FourDemo
{
     class HelperMethods
    {

        

        //add New Kitty
        public static void AddKittyToDB(CreateKitty kitty)
        {
            using (var context = new TransactionContext())
            {
                context.CreateKitties.Add(kitty);
            }
        }
        //Add new Expense
        public static void AddExpenseToDB(Expense expense)
        {
            using (var context = new TransactionContext())
            {
                context.Expenses.Add(expense);

            }
        }
        // Add new Participant
        public static void AddParticipantToDB(Participant participant)
        {
            using (var context = new TransactionContext())
            {
                context.Participants.Add(participant);

            }
        }

        // Add new Income
        public static void AddIncomeToDB(Income income)
        {
            using (var context = new TransactionContext())
            {
                context.Incomes.Add(income);
                context.SaveChanges();
            }
        }
        // Add new Money Given
        public static void AddMoneyGivenToDB(MoneyGiven money)
        {
            using (var context = new TransactionContext())
            {
                context.MoneyGiven.Add(money);
                context.SaveChanges();
            }
        }

        // Add new Comment
        public static void AddCommentToDB(Comment comment)
        {
            using (var context = new TransactionContext())
            {
                context.Comments.Add(comment);
                context.SaveChanges();


            }
        }

        // Delete Kitty
        public static void DeleteQueryKitties(Func<CreateKitty, bool> filter)
        {
            using (var context = new TransactionContext())
            {
                ;
                foreach (var k in context.CreateKitties)
                {
                    if (filter(k))
                    {
                        context.CreateKitties.Remove(k);
                    }
                }
            }
        }

        // Delete Expense
        public static void DeleteQueryExpenses(Func<Expense, bool> filter)
        {
            using (var context = new TransactionContext())
            {
                
                foreach (var e in context.Expenses)
                {
                    if (filter(e))
                    {
                        context.Expenses.Remove(e);
                    }
                }
            }
        }
        // Delete Participant
        public static void DeleteQueryParticipant(Func<Participant, bool> filter)
        {
            using (var context = new TransactionContext())
            {

                foreach (var p in context.Participants)
                {
                    if (filter(p))
                    {
                        context.Participants.Remove(p);
                    }
                }
            }
        }

        // Clear Kitties
        public static void Clearkitties()
        {


            using (var context = new TransactionContext())
            {
                foreach (var kitty in context.CreateKitties)
                {
                    context.CreateKitties.Remove(kitty);


                }
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT (CreateKitties, RESEED, 1)");
                context.SaveChanges();
            }
        }
        // Clear Expenses
        public static void ClearExpenses()
        {


            using (var context = new TransactionContext())
            {
                foreach (var expense in context.Expenses)
                {
                    context.Expenses.Remove(expense);


                }
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT (Expenses, RESEED, 1)");
                context.SaveChanges();
            }
        }


        // Display all expenses for specific Kitty
        public static void DisplayExpensesInkitty(Func<CreateKitty, bool> kittyFilter, Func<Expense, bool> expenseFilter)
        {
            using (var context = new TransactionContext())
            {
                foreach (var s in context.CreateKitties)
                {
                    if (kittyFilter(s))
                    {
                        Console.WriteLine($"\n{s.EventName} event is selected");
                        foreach (var n in context.Expenses)
                        {
                            if (expenseFilter(n))
                            {
                                Console.WriteLine($"\n{n.Name} made this expense at {n.When} \n For this reason:{n.WhatFor}, \n Cost of this expense was:{n.Amount}");
                            }
                        }
                    }
                }
            }
        }
        // Display all Comments for a specific Person

        public static void DisplayCommentsForPerson(Func<Participant, bool> personFilter, Func<Comment, bool> commentFilter)
        {
            using (var context = new TransactionContext())
            {
                foreach (var s in context.Participants)
                {
                    if (personFilter(s))
                    {
                        Console.WriteLine($"\n{s.Name} is selected");
                        foreach (var n in context.Comments)
                        {
                            if (commentFilter(n))
                            {
                                Console.WriteLine($"\n{n.PersonWhoCreate} added this comment: {n.CommentText}" );
                            }
                        }
                    }
                }
            }

        }

    }
}

