namespace NumberWordSpecs.NumberToWords
{
    using System;

    using Machine.Fakes;
    using Machine.Specifications;

    using NumberWord;

    public abstract class WithNumberToWords : WithSubject<NumberToWords>
    {
        protected static string Result;

        protected static int Input;

        protected static Exception Exception;

        private Because of = () =>
        {
            try
            {
                Result = NumberToWords.Convert(Input);
            }
            catch (Exception ex)
            {
                Exception = ex;
            }
        };
    }

    public class when_given_thirteen : WithNumberToWords
    {
        private Establish context = () => Input = 13;

        private It should_return_thirteen = () => Result.ToLower().ShouldEqual("thirteen");
    }

    public class when_given_thirty_two : WithNumberToWords
    {
        private Establish context = () => Input = 32;

        private It should_return_thirty_two_with_hyphen = () => Result.ToLower().ShouldEqual("thirty-two");
    }

    public class when_given_one_hundred : WithNumberToWords
    {
        private Establish context = () => Input = 100;

        private It should_return_one_hundred_with_space = () => Result.ToLower().ShouldEqual("one hundred");
    }

    public class when_given_three_hundred_and_forty_two : WithNumberToWords
    {
        private Establish context = () => Input = 342;

        private It should_return_three_hundred_and_forty_two = () => Result.ToLower().ShouldEqual("three hundred and forty-two");
    }

    public class when_given_one_thousand : WithNumberToWords
    {
        private Establish context = () => Input = 1000;

        private It should_return_one_thousand = () => Result.ToLower().ShouldEqual("one thousand");
    }

    public class when_given_one : WithNumberToWords
    {
        private Establish context = () => Input = 1;

        private It should_return_one = () => Result.ToLower().ShouldEqual("one");
    }

    public class when_given_zero : WithNumberToWords
    {
        private Establish context = () => Input = 0;

        private It should_throw_an_argument_exception = () => Exception.ShouldBeOfExactType<ArgumentException>();
    }

    public class when_given_one_thousand_and_one : WithNumberToWords
    {
        private Establish context = () => Input = 1001;

        private It should_throw_an_argument_exception = () => Exception.ShouldBeOfExactType<ArgumentException>();
    }

    public class when_given_one_hundred_and_one : WithNumberToWords
    {
        private Establish context = () => Input = 101;

        private It should_return_one_hundred_and_one = () => Result.ToLower().ShouldEqual("one hundred and one");
    }

    public class when_given_one_hundred_and_eleven : WithNumberToWords
    {
        private Establish context = () => Input = 111;

        private It should_return_one_hundred_and_eleven = () => Result.ToLower().ShouldEqual("one hundred and eleven");
    }

    public class when_given_one_hundred_and_twenty : WithNumberToWords
    {
        private Establish context = () => Input = 120;

        private It should_return_one_hundred_and_twenty = () => Result.ToLower().ShouldEqual("one hundred and twenty");
    }
}
