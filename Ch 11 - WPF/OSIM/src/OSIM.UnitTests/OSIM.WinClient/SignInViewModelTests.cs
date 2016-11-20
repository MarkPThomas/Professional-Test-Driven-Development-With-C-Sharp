using System;
using NBehave.Spec.NUnit;
using NUnit.Framework;
using OSIM.WinClient.ViewModels;

namespace OSIM.UnitTests.OSIM.WinClient
{

    public class when_signing_in : Specification { }

    public class and_signing_in_with_a_valid_username_and_valid_password : when_signing_in
    {
        protected override void Establish_context()
        {
            base.Establish_context();

            _signInViewModel = new SignInViewModel();
            _signInViewModel.Username = "username";
            _signInViewModel.Password = "password";
        }

        private string _result;
        private bool _canSignIn;
        private ISignInViewModel _signInViewModel;
        protected override void Because_of()
        {
            _canSignIn = _signInViewModel.CanSignIn;
            _signInViewModel.SignIn();
            _result = _signInViewModel.ErrorMessage;
        }

        [Test]
        public void then_should_return_errormessage()
        {
            _canSignIn.ShouldBeTrue();
            _result.ShouldEqual(string.Empty);
        }
    }

    public class and_signing_in_with_a_valid_username_and_invalid_password : when_signing_in
    {
        protected override void Establish_context()
        {
            base.Establish_context();
            _signInViewModel = new SignInViewModel();
            _signInViewModel.Username = "username";
            _signInViewModel.Password = "badpassword";
        }

        private string _result;
        private bool _canSignIn;
        private ISignInViewModel _signInViewModel;
        protected override void Because_of()
        {
            _canSignIn = _signInViewModel.CanSignIn;
            _signInViewModel.SignIn();
            _result = _signInViewModel.ErrorMessage;
        }

        [Test]
        public void then_should_return_errormessage()
        {
            _canSignIn.ShouldBeTrue();
            _result.ShouldEqual("Incorrect username or password.");
        }
    }

    public class when_attempting_to_sign_in : Specification
    {
    }

    public class and_username_and_password_are_blank : when_attempting_to_sign_in
    {
        protected override void Establish_context()
        {
            base.Establish_context();
            _signInViewModel = new SignInViewModel();
        }

        private bool _result;
        private ISignInViewModel _signInViewModel;
        protected override void Because_of()
        {
            _signInViewModel.Username = string.Empty;
            _signInViewModel.Password = string.Empty;
            _result = _signInViewModel.CanSignIn;
        }

        [Test]
        public void then_cansignin_should_be_false()
        {
            _result.ShouldEqual(false);
        }
    }

    public class and_username_and_password_are_not_blank : when_attempting_to_sign_in
    {
        protected override void Establish_context()
        {
            base.Establish_context();
            _signInViewModel = new SignInViewModel();
        }

        private bool _result;
        private ISignInViewModel _signInViewModel;
        protected override void Because_of()
        {
            _signInViewModel.Username = "username";
            _signInViewModel.Password = "password";
            _result = _signInViewModel.CanSignIn;
        }

        [Test]
        public void then_CanSignIn_should_be_true()
        {
            _result.ShouldEqual(true);
        }
    }

    public class and_wanting_to_cancel : when_attempting_to_sign_in
    {
        protected override void Establish_context()
        {
            base.Establish_context();
            _signInViewModel = new SignInViewModel();
        }

        private bool _result;
        private ISignInViewModel _signInViewModel;
        protected override void Because_of()
        {
            _result = _signInViewModel.CanCancel;
        }

        [Test]
        public void then_cancancel_should_be_true()
        {
            _result.ShouldEqual(true);
        }
    }


}