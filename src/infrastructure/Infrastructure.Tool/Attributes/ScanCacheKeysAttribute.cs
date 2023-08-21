using System;

namespace Infrastructure.Cache.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class ScanCacheKeysAttribute : Attribute
{
}