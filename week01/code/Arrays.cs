public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Create an array of doubles with the size specified by 'length'
        var result = new double[length];

        // Loop from 1 to 'length' inclusive, this to calculate each multiple
        for (var i = 1; i <= length; i++)
        {
            // Multiply 'number' by the current loop index 'i' to get the next multiple
            // Store it in the array at index 'i - 1' because array indexing starts at 0
            result[i - 1] = number * i;
        }
        // Return the array containing all the multiples.
        return result;
    }


    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Make sure the rotation is not bigger than the list
        amount = amount % data.Count;

        // If amount is 0, no rotation is needed
        if (amount == 0)
            return;

        // Take the last 'amount' elements to move to the front
        List<int> endSlice = data.GetRange(data.Count - amount, amount);

        // Take the first part of the list (everything else)
        List<int> startSlice = data.GetRange(0, data.Count - amount);

        // Clear the original list so we can rebuild it
        data.Clear();

        // Add the last elements first (they move to the front)
        data.AddRange(endSlice);

        // Add the first elements after
        data.AddRange(startSlice);
    }
}
