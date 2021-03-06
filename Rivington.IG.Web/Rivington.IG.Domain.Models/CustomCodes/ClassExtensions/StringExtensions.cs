﻿using System;

public static class StringExtensions
{
  public static bool ToBoolean(this string value)
  {
    if(string.IsNullOrEmpty(value))
      throw new InvalidCastException("You can't cast that value to a bool!");

    switch (value.ToLower())
    {
      case "true":
        return true;
      case "t":
        return true;
      case "1":
        return true;
      case "0":
        return false;
      case "false":
        return false;
      case "f":
        return false;
      default:
        throw new InvalidCastException("You can't cast that value to a bool!");
    }
  }
}