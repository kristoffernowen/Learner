using Learner.Application.Contracts.Repos;
using Learner.Domain.Models;

namespace Learner.Persistence.Repos;

public class FactRepository(SqlContext context) : Repository<FactInObject>(context), IFactRepository
{}