const API_BASE_URL = 'http://10.0.2.2:5020/api';

async function request<T>(endpoint: string, options?: RequestInit): Promise<T> {
  const response = await fetch(`${API_BASE_URL}${endpoint}`, {
    headers: {
      'Content-Type': 'application/json',
      ...(options?.headers ?? {}),
    },
    ...options,
  });

  if (!response.ok) {
    throw new Error(`Request failed with status ${response.status}`);
  }

  return response.json() as Promise<T>;
}

export const apiService = {
  get: <T>(endpoint: string) => request<T>(endpoint),
  post: <TResponse, TBody>(endpoint: string, body: TBody) =>
    request<TResponse>(endpoint, {
      method: 'POST',
      body: JSON.stringify(body),
    }),
  put: <TResponse, TBody>(endpoint: string, body: TBody) =>
    request<TResponse>(endpoint, {
      method: 'PUT',
      body: JSON.stringify(body),
    }),
  delete: <TResponse>(endpoint: string) =>
    request<TResponse>(endpoint, {
      method: 'DELETE',
    }),
};