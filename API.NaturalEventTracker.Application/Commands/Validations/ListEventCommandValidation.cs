using API.NaturalEventTracker.Application.Commands.ValueObjects;
using FluentValidation;
using FluentValidation.Validators;
using System;

namespace API.NaturalEventTracker.Application.Commands.Validations
{
    public class ListEventCommandValidation : AbstractValidator<ListEventCommand>
    {
        public ListEventCommandValidation()
        {
            RuleFor(a => a.Limit)
                 .Custom((limit, context) =>
                 {
                     CheckLimitValue(limit, context);
                 });

            RuleFor(a => a.Days)
                 .Custom((days, context) =>
                 {
                     CheckDaysValue(days, context);
                 });

            RuleFor(a => a)
                 .Custom((command, context) =>
                 {
                     CheckStatusValue(command, context);
                 });

            RuleFor(a => a)
                .Custom((command, context) =>
                {
                    CheckDatesValues(command, context);
                });

            RuleFor(a => a)
                .Custom((command, context) =>
                {
                    CheckOrderValue(command, context);
                });

            RuleFor(a => a)
                .Custom((command, context) =>
                {
                    CheckOrderFieldValue(command, context);
                });
        }

        private void CheckLimitValue(int? limit, CustomContext context)
        {
            if (limit != null && limit < 1)
                context.AddFailure("The Limit value must be greater than zero.");
        }
        private void CheckDaysValue(int? days, CustomContext context)
        {
            if (days != null && days < 1)
                context.AddFailure("The Days value must be greater than zero.");
        }
        private void CheckStatusValue(ListEventCommand commad, CustomContext context)
        {
            if (!string.IsNullOrEmpty(commad.Status))
            {
                if (Enum.IsDefined(typeof(EventStatus), commad.Status))
                {
                    if (commad.Status.Equals(Enum.GetName(typeof(EventStatus), EventStatus.Closed)) && commad.Limit == null || commad.Limit < 1)
                    {
                        context.AddFailure("Enter a Limit value to search closed events");
                    }
                }
                else
                {
                    context.AddFailure("Unable to find the value of the entered Status.");
                }
            }
        }
        private void CheckDatesValues(ListEventCommand commad, CustomContext context)
        {
            DateTime start = new DateTime();
            DateTime end = new DateTime();


            if (!string.IsNullOrEmpty(commad.StartingDate) && !DateTime.TryParse(commad.StartingDate, out start))
            {
                context.AddFailure("The StartingDate is Invalid.");
            }

            if (!string.IsNullOrEmpty(commad.EndingDate) && !DateTime.TryParse(commad.EndingDate, out end))
            {
                context.AddFailure("The EndingDate is Invalid.");
            }

            if (start.Date != default && end.Date != default)
            {
                if (DateTime.Compare(start, end) > 0)
                    context.AddFailure("The StartingDate is greater than the EndingDate.");
            }
        }
        private void CheckOrderValue(ListEventCommand commad, CustomContext context)
        {
            if (!string.IsNullOrEmpty(commad.OrderBy))
            {
                if (!Enum.IsDefined(typeof(OrderTypes), commad.OrderBy))
                {
                    context.AddFailure("Unable to find the value of the entered OrderBy.");
                }
            }
        }
        private void CheckOrderFieldValue(ListEventCommand commad, CustomContext context)
        {
            if (!string.IsNullOrEmpty(commad.OrderField))
            {
                if (!Enum.IsDefined(typeof(OrderFields), commad.OrderField))
                {
                    context.AddFailure("Unable to find the value of the entered OrderField.");
                }
            }
        }
    }
}
