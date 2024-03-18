export function GenerateClassType(isActive) {
    if (isActive) {
      return "nav-link active";
    }
    return "nav-link";
  }
export const requestUrl = 'https://localhost:7002/api/';