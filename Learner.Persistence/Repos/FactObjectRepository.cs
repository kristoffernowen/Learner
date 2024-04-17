using Learner.Application.Contracts.Repos;
using Learner.Domain.Models;

namespace Learner.Persistence.Repos;

public class FactObjectRepository(SqlContext context) : Repository<FactObject>(context), IFactObjectRepository 
{}