Built in VS2022 and .NET 6

Test by running the single test in the project WF.Test.Integration

If all is working then the test should pass and three new files should appear in WF\TestResults

Notes:
- Used CsvHelper for this, it's perfect for the job
- In this context I've called a transaction enriched with security and portfolio instances an Order
- In the interests of time I've omitted to do validation, exception handling, logging etc.
- For the same reason I haven't done any unit testing - just the one integration test with the expectation that the output will be manually checked.
