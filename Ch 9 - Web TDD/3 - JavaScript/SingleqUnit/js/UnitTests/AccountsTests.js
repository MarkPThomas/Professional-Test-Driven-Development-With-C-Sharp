// Note: The reference tag allows qUnit to run without an HTML harness file.
//          This seems to cause Chutzpah to work better with VS. 
//          With an HTML test harness, "Test Explorer" & VS seem to run the tests twice, failing the first time.
//          However, the HTML test harness can be used to view results in the browser.
//  Steps for Unit Tests:
//  1. Use HTML test harness file (place examplefile within 'UnitTests' folder), refresh in browser.
//  2. Have reference below, and in "Test Explorer" window, choose to "Run All" each time the tests are to be updated.
//      You could toggle "Run Tests After Build" in "Test Explorer", but this seems to not be working in VS.

/// <reference path="../Account.js" />

QUnit.test('Should_Create_An_Account_Object_With_Balance', function (assert) {
    var checkingAccount = new Account(564858510, 600);
    assert.equal(checkingAccount.Balance, 600);
});

QUnit.test('Should_Transfer_From_Checking_To_Savings_Successfully', function (assert) {
    var checkingAccount = new Account(564858510, 600);
    var savingsAccount = new Account(564858507, 100);

    checkingAccount.Transfer(savingsAccount, 100);
    assert.equal(savingsAccount.Balance, 200);
    assert.equal(checkingAccount.Balance, 500);
});

QUnit.test('Should_Not_Transfer_From_When_The_From_Account_Has_Insufficent_Funds', function (assert) {
    var checkingAccount = new Account(564858510, 600);
    var savingsAccount = new Account(564858507, 100);

    checkingAccount.Transfer(savingsAccount, 700);
    assert.equal(savingsAccount.Balance, 100);
    assert.equal(checkingAccount.Balance, 600);
});