using Learner.Application.Contracts.Repos;
using Learner.Domain.Models;

namespace Learner.Persistence.Repos;

public class FactRepository(SqlContext context) : Repository<Fact>(context), IFactRepository
{}