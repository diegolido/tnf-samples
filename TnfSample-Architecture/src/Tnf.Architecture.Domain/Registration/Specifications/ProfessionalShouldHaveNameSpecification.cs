﻿using System;
using System.Linq.Expressions;
using Tnf.Specifications;

namespace Tnf.Architecture.Domain.Registration.Specifications
{
    internal class ProfessionalShouldHaveNameSpecification : Specification<Professional>
    {
        public override Expression<Func<Professional, bool>> ToExpression()
        {
            return (p) => !string.IsNullOrWhiteSpace(p.Name);
        }
    }
}
