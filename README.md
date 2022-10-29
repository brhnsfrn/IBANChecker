# IBANChecker
IBAN Checker with Modulo 97 Algorithm

## Example

Lets take iban number for a Central Bank of the Republic of Turkey and disect the steps.

1. Move last four to the end

    `TR470000100100000350930001 -> 0000100100000350930001TR47`

1. Replace characters with digits

    `0000100100000350930001TR47 -> 0000100100000350930001292747`

1. Start iteration over nine digit numbers
    1. `N = 000010010, d = N % 97 = 19`
    1. `N = 19000035093, d = N % 97 = 43`
    1. `N = 430001292747, d = N % 97 = 1`

1. If `d == 1` then valid; otherwise invalid.

The implemention make us of a specialized "iterator" that perform step 1 and 2 without any allocations.
