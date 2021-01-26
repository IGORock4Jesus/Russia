#pragma once

#include <wrl.h>
#include <d3d9.h>

bool InitializeRenderer(HWND hwnd, int width, int height);
void ReleaseRenderer();

Microsoft::WRL::ComPtr<IDirect3DDevice9> GetDevice();

