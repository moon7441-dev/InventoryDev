Unity 인벤토리 시스템 구현.

## 구현 기능
- 캐릭터 정보 표시
- UI 전환 (메인 / 스테이터스 / 인벤토리)
- 아이템 획득 및 슬롯 생성
- 장비 장착/해제 및 능력치 반영

## 실행 방법

1. Unity에서 프로젝트 열기
2. `MainScene` 실행
3. UI 버튼을 통해 화면 전환

## 테스트 체크리스트

-  메인 UI에 캐릭터 정보 출력
-  Status 화면에서 능력치 반영
-  슬롯 클릭으로 장착/해제 동작
-  장비 반영 후 Status UI 갱신

## Troubleshooting (문제 해결 기록)

Status / Inventory 에 값이 표시되지 않음 :	Canvas가 비활성 상태일 때 SetPlayer가 호출되어 UI가 갱신되지 않음	OnEnable()에서 GameManager.Instance.Player 데이터를 받아 UI를 강제 Refresh하도록 수정	✔ 해결 /n
슬롯 클릭해도 UI 갱신 안 됨 :	Inventory UI만 갱신되고 Status UI가 갱신되지 않음	OnClickSlot()에서 UIManager.Instance.Status.RefreshUI() 호출 추가	✔ 해결 /n
UISlot 프리팹이 복제되지만 텍스트가 비어있음	UISlot 프리팹이 Inspector에서 UI 요소가 연결되지 않은 상태	UISlot prefab을 열어 textName, textType, button 연결	✔ 해결 /n

## 배운 점
- UI 참조 연결 방식
- 동적 오브젝트 생성 패턴
