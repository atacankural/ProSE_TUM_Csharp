using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace FourDemo
{
    public class Program
    {
        static void Main()
        {
            #region Data for the Database
            var person1 = new Participant()
            {
                Name = "Ece",
                Email = "ge84his@mytum.de",
            };
            var person2 = new Participant()
            {
                Name = "Ata",
                Email = "ge47hka@mytum.de",
            };
            var kitty1 = new CreateKitty()
            {
                EventName = "Paris Tour",
                MoneyType = HomeCurrency.Euro,
                ParticipantsList = new List<Participant>() { person1, person2 }
            };
            var comment1 = new Comment()
            {
                PersonWhoCreate = "Ece",
                CommentText = "Please pay your debts in Cash",
            };

            var expense1 = new Expense()
            {
                Name = "Ece",
                Amount = 50,
                WhatFor = "Bought train tickets",
                When = "(2022, 12, 30)",
            };
            var expense2 = new Expense()
            {
                Name = "Ece",
                Amount = 86,
                WhatFor = "Cost of rental car",
                When = "(2022, 12, 29)",
            };
            
                       
            kitty1.Participants.Add(person1);
            kitty1.Participants.Add(person2);
            person1.Comments.Add(comment1);
            person1.Expenses.Add(expense1);
            person1.Expenses.Add(expense2);
            #endregion

            HelperMethods.AddKittyToDB(kitty1);

            HelperMethods.AddKittyToDB(kitty1);
            HelperMethods.AddParticipantToDB(person1);
            HelperMethods.AddParticipantToDB(person2);
            HelperMethods.AddExpenseToDB(expense1);
            HelperMethods.AddExpenseToDB(expense2);
            HelperMethods.AddCommentToDB(comment1);



            HelperMethods.DisplayExpensesInkitty(kitty => kitty.EventName == "Paris Tour", expenses => expenses.Name == "Ece");


            HelperMethods.DisplayCommentsForPerson(participant => participant.Name == "Ece", comment => comment.PersonWhoCreate =="Ece");
        }
    }
}