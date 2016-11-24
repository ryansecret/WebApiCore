param(
    [int] $iterations = 6000,
    [int] $rps = 500,
    [string][ValidateSet("plaintext")] $variation = "plaintext")

if ($variation -eq "plaintext")
{
    $url = "http://localhost:6008/auth/test"
}

Write-Host -ForegroundColor Green Beginning workload
Write-Host "`& loadtest -k -n $iterations -c 100 --rps $rps $url"
Write-Host

& loadtest -k -n $iterations -c 100 --rps $rps $url