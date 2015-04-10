namespace NumberWordSpecs.LetterCounter
{
    using Machine.Fakes;
    using Machine.Specifications;

    using NumberWord;

    public abstract class with_letter_counter : WithSubject<LetterCounter>
    {
        protected static string Input;

        protected static int Result;

        private Because of = () => Result = LetterCounter.Count(Input);
    }

    public class when_given_one : with_letter_counter
    {
        private Establish context = () => Input = "one";

        private It should_return_three = () => Result.ShouldEqual(3);
    }

    public class when_given_forty_two : with_letter_counter
    {
        private Establish context = () => Input = "forty-two";

        private It should_return_eight = () => Result.ShouldEqual(8);
    }

    public class when_given_one_hundred : with_letter_counter
    {
        private Establish context = () => Input = "one hundred";

        private It should_return_ten = () => Result.ShouldEqual(10);
    }

    public class when_given_three_hundred_and_forty_two : with_letter_counter
    {
        private Establish context = () => Input = "three hundred and forty-two";

        private It should_return_twenty_three = () => Result.ShouldEqual(23);
    }
}